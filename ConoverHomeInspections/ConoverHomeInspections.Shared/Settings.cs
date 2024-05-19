// ConoverHomeInspections
// Settings.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
namespace ConoverHomeInspections.Shared
{
    public static class Settings
    {
        public const string ApiBaseUrl = "https://conoverhomeinspections.com/api";
        public static List<ImageData> HouseImgList = new List<ImageData>
                                                     {
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 1",
                                                             ImgUrl = "/images/house-1.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 2",
                                                             ImgUrl = "/images/house-2.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 3",
                                                             ImgUrl = "/images/house-3.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 4",
                                                             ImgUrl = "/images/house-4.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 5",
                                                             ImgUrl = "/images/house-5.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 6",
                                                             ImgUrl = "/images/house-6.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 7",
                                                             ImgUrl = "/images/house-7.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 8",
                                                             ImgUrl = "/images/house-8.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 9",
                                                             ImgUrl = "/images/house-9.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 10",
                                                             ImgUrl = "/images/house-10.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 11",
                                                             ImgUrl = "/images/house-11.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                            new ImageData()
                                                            {
                                                                ImgName = "House 12",
                                                                ImgUrl = "/images/quarryville_house.jpg",
                                                                ImgAlt = "A rustic house in Quarryville, PA. It's covered by the shade of a tree, the sky is gray, and the grass is green. There is a brown, wooden, patio leading up to the front door set in the center of the house's face."
                                                            },
                                                     };
        public static ImageData GetRandomHouseImage()
        {
            Random random = new Random();
            return HouseImgList[random.Next(HouseImgList.Count)];
        }
    }
}