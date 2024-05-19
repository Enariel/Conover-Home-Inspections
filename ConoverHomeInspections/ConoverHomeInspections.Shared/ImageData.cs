// ConoverHomeInspections
// ImageData.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ImageData
    {
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public string ImgAlt { get; set; }
        public int Order { get; set; } = 0;
    }
}