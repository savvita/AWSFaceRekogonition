using AForge.Video;
using AForge.Video.DirectShow;
using Amazon.Rekognition.Model;
using AWSFaceRekoginition.AWSAccess;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Imaging;
using Image = System.Drawing.Image;

namespace AWSFaceRekogonition
{
    public partial class RekoginitionForm : Form
    {
        private FilterInfoCollection videoDevices = null!;
        private ArrayList listCamera = new ArrayList();

        private VideoCaptureDevice? videoDevice;

        private VideoCapabilities[]? snapshotCapabilities;

        private static bool needSnapshot = false;

        private static string? _camera;

        public delegate void CaptureSnapshotManifast(Bitmap image);

        private readonly Rekoginition? _rekoginition;
        private readonly string? _bucket;

        private string pathFolder = Application.StartupPath + @"\ImageCapture\";

        public string? Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }
        public RekoginitionForm()
        {
            InitializeComponent();
            GetListCamera();
        }

        public RekoginitionForm(string accessKey, string secretKey, Amazon.RegionEndpoint region, string bucketName) : this()
        {
            _rekoginition = new Rekoginition(accessKey, secretKey, region);
            _bucket = bucketName;
        }

        private void GetListCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if(videoDevices.Count != 0)
            {
                foreach(FilterInfo item in videoDevices)
                {
                    this.cameraComboBox.Items.Add(item.Name);
                }
            }
            else
            {
                this.cameraComboBox.Items.Add("No DirectShow devices found");
            }

            this.cameraComboBox.SelectedIndex = 0;
        }

        private void OpenCamera()
        {
            try
            {
                Camera = this.cameraComboBox.SelectedIndex.ToString();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if(videoDevices.Count > 0)
                {
                    foreach(FilterInfo item in videoDevices)
                    {
                        listCamera.Add(item.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Camera devices found");
                }

                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(Camera)].MonikerString);
                snapshotCapabilities = videoDevice.VideoCapabilities;

                if (snapshotCapabilities.Length == 0)
                {
                    MessageBox.Show("Camera Capture Not supported");
                }

                OpenVideoSource(videoDevice);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenVideoSource(IVideoSource source)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CloseCurrentVideoSource();

                this.videoSourcePlayer.VideoSource = source;
                this.videoSourcePlayer.Start();

                this.Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void CloseCurrentVideoSource()
        {
            try
            {
                if(this.videoSourcePlayer.VideoSource != null)
                {
                    this.videoSourcePlayer.SignalToStop();
                    for (int i = 0; i < 30; i++)
                    {
                        if(!this.videoSourcePlayer.IsRunning)
                        {
                            break;
                        }

                        Thread.Sleep(100);
                    }

                    if(this.videoSourcePlayer.IsRunning)
                    {
                        this.videoSourcePlayer.Stop();
                    }

                    this.videoSourcePlayer.VideoSource = null;
                }
            }
            catch
            {

            }
        }

        private async void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;
                var prev = picBox.Image;
                this.picBox.Image = image;
                this.picBox.Update();

                if (prev != null)
                {
                    prev.Dispose();
                }

                string imageName = Guid.NewGuid().ToString() + ".jpg";
                string imagePath = Path.Combine(pathFolder, imageName);

                if (!Directory.Exists(pathFolder))
                {
                    Directory.CreateDirectory(pathFolder);
                }

                this.picBox.Image.Save(imagePath, ImageFormat.Jpeg);

                if (_rekoginition != null && _bucket != null)
                {
                    await _rekoginition.UploadToBucketAsync(_bucket, imageName, File.Open(imagePath, FileMode.Open));
                    var faces = await _rekoginition.GetFaces(_bucket, imageName);
                    this.picBox.Image = Image.FromFile(imagePath);
                    this.picBox.Update();

                    BoundFaces(faces);

                    //File.Delete(imagePath);
                }

            }
            catch { }
        }

        private void BoundFaces(List<BoundingBox> bounds)
        {
            foreach (var item in bounds)
            {

                //double multiplyH = (double)this.picBox.Height / (double)this.picBox.Image.Height;
                //double multiplyW = (double)this.picBox.Width / (double)this.picBox.Image.Width;

                //int left = (int)(multiplyW * item.Left * this.picBox.Image.Width);
                //int top = (int)(multiplyH * item.Top * this.picBox.Image.Height);
                //int width = (int)(multiplyW * item.Width * this.picBox.Image.Width);
                //int height = (int)(multiplyH * item.Height * this.picBox.Image.Height);
                double multiplyH = (double)this.picBox.Height / (double)this.picBox.Image.Height;
                double multiplyW = (double)this.picBox.Width / (double)this.picBox.Image.Width;

                double multiply = multiplyH < multiplyW ? multiplyH : multiplyW;

                int left = (int)((this.picBox.Width - this.picBox.Image.Width * multiply) / 2 + this.picBox.Image.Width * multiply * item.Left);
                int top = (int)((this.picBox.Height - this.picBox.Image.Height * multiply) / 2 + this.picBox.Image.Height * multiply * item.Top);
                int width = (int)(multiply * item.Width * this.picBox.Image.Width);
                int height = (int)(multiply * item.Height * this.picBox.Image.Height);

                this.picBox.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(left, top, width, height));
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

        private void snapshotBtn_Click(object sender, EventArgs e)
        {
            needSnapshot = true;
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);

                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
                brush.Dispose();

                if (needSnapshot)
                {
                    this.Invoke(new CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), image);
                }

                g.Dispose();
            }
            catch { }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            CloseCurrentVideoSource();
        }

        private async void openBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.picBox.Image = Image.FromFile(dialog.FileName);
                    this.picBox.Update();

                    if (_rekoginition != null && _bucket != null)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        await _rekoginition.UploadToBucketAsync(_bucket, fileName, dialog.OpenFile());
                        var faces = await _rekoginition.GetFaces(_bucket, fileName);

                        BoundFaces(faces);

                    }
                }
                catch
                {

                }
            }
        }

        private void RekoginitionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentVideoSource();
        }
    }
}
