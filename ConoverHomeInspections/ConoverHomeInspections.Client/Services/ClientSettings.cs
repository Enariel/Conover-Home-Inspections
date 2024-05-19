// ConoverHomeInspections
// ClientSettings.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
using ConoverHomeInspections.Shared;
using MudBlazor;
using MudBlazor.Utilities;

namespace ConoverHomeInspections.Client.Services
{
    public static class ClientSettings
    {
        public static List<ImageData> HouseImgList = new List<ImageData>
                                                     {
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 1",
                                                             ImgUrl = "images/house-1.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 2",
                                                             ImgUrl = "images/house-2.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 3",
                                                             ImgUrl = "images/house-3.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 4",
                                                             ImgUrl = "images/house-4.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 5",
                                                             ImgUrl = "images/house-5.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 6",
                                                             ImgUrl = "images/house-6.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 7",
                                                             ImgUrl = "images/house-7.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 8",
                                                             ImgUrl = "images/house-8.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 9",
                                                             ImgUrl = "images/house-9.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 10",
                                                             ImgUrl = "images/house-10.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                         new ImageData()
                                                         {
                                                             ImgName = "House 11",
                                                             ImgUrl = "images/house-11.jpg",
                                                             ImgAlt = "Picture of a house."
                                                         },
                                                     };

        public static MudTheme GetSiteTheme()
        {
            var theme = new MudTheme
                        {
                            PaletteDark = new PaletteDark
                                          {
                                              Primary = new MudColor("#F3BA04"),
                                              Secondary = new MudColor("#F69D03"),
                                              Tertiary = new MudColor("#F8192C"),
                                              HoverOpacity = 50,
                                              GrayDefault = "#898686",
                                              Black = new MudColor("#191919"),
                                              // Info = null,
                                              // Success = null,
                                              // Warning = null,
                                              // Error = null,
                                              Dark = new MudColor("#1D1B22"),
                                              // TextPrimary = null,
                                              // TextSecondary = null,
                                              // TextDisabled = null,
                                              // ActionDefault = null,
                                              // ActionDisabled = null,
                                              // ActionDisabledBackground = null,
                                              // Background = null,
                                              // BackgroundGrey = null,
                                              Surface = new MudColor("#494949"),
                                              // DrawerBackground = null,
                                              // DrawerText = null,
                                              // DrawerIcon = null,
                                              // AppbarBackground = null,
                                              // AppbarText = null,
                                              // LinesDefault = null,
                                              // LinesInputs = null,
                                              // TableLines = null,
                                              // TableStriped = null,
                                              // Divider = null,
                                              // DividerLight = null,
                                              // ChipDefault = null,
                                              // ChipDefaultHover = null
                                          },
                            Typography = new Typography
                                         {
                                             // Default = null,
                                             // H1 = null,
                                             // H2 = null,
                                             // H3 = null,
                                             // H4 = null,
                                             // H5 = null,
                                             // H6 = null,
                                             // Subtitle1 = null,
                                             // Subtitle2 = null,
                                             // Body1 = null,
                                             // Body2 = null,
                                             // Button = null,
                                             // Caption = null,
                                             // Overline = null
                                         },
                            // LayoutProperties = null,
                            // ZIndex = null,
                            // PseudoCss = null
                        };
            return theme;
        }

        public static ImageData GetRandomHouseImage()
        {
            Random random = new Random();
            return HouseImgList[random.Next(HouseImgList.Count)];
        }
    }
}