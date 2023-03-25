using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace AWSFaceRekoginition.AWSAccess
{
    public class Rekoginition
    {
        private readonly AmazonS3Client _s3Client;
        private readonly string _secretKey;
        private readonly string _accessKey;
        public Rekoginition(string accessKey, string secretKey, Amazon.RegionEndpoint region)
        {
            _secretKey = secretKey;
            _accessKey = accessKey;
            _s3Client = new AmazonS3Client(accessKey, secretKey, region);
        }

        public async Task<bool> UploadToBucketAsync(string bucketName, string objectName, Stream stream)
        {

            try
            {
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    InputStream = stream
                };

                var response = await _s3Client.PutObjectAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<BoundingBox>> GetFaces(string bucketName, string objectName)
        {
            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(
                _accessKey,
                _secretKey,
                Amazon.RegionEndpoint.EUWest2);

            DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
            {
                Image = new Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Name = objectName,
                        Bucket = bucketName
                    }
                }
            };

            var results = new List<BoundingBox>();

            try
            {
                DetectFacesResponse detectFacesResponse = await rekognitionClient.DetectFacesAsync(detectFacesRequest);

                foreach (FaceDetail face in detectFacesResponse.FaceDetails)
                {
                    results.Add(face.BoundingBox);
                }
            }
            catch
            {
            }

            return results;
        }
    }
}
