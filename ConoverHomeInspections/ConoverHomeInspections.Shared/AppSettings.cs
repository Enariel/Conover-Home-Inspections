// ConoverHomeInspections
// ClientSettings.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
using MudBlazor;
using MudBlazor.Utilities;

namespace ConoverHomeInspections.Shared
{
    public static class AppSettings
    {
        /// <summary>
        /// Gets a list of images to be used in the carousel.
        /// </summary>
        public static readonly List<ImageData> HouseImgList = new List<ImageData>
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

        /// <summary>
        /// Gets the site theming information.
        /// </summary>
        /// <returns><see cref="MudTheme"/></returns>
        public static MudTheme GetSiteTheme()
        {
            var theme = new MudTheme
                        {
                            PaletteDark = new PaletteDark
                                          {
                                              Primary = new MudColor("#F5CB0C"),
                                              PrimaryContrastText = new MudColor("#FFFFFF"),
                                              Secondary = new MudColor("#F59616"),
                                              SecondaryContrastText = new MudColor("#FFFFFF"),
                                              Tertiary = new MudColor("#F46200"),
                                              TertiaryContrastText = new MudColor("#FFFFFF"),
                                              HoverOpacity = 50,
                                              Black = new MudColor("#1D1B22"),
                                              Dark = new MudColor("#1D1B22"),
                                              TextPrimary = "rgba(255,255,255, 0.70)",
                                              TextSecondary = "rgba(255,255,255, 0.50)",
                                              TextDisabled = "rgba(255,255,255, 0.2)",
                                              Surface = new MudColor("#3D3E4A"),
                                          },
                            Typography = new Typography
                                         {
                                             Default = new Default
                                                       {
                                                           FontFamily = new string[]
                                                                        {
                                                                            "Forum",
                                                                            "serif",
                                                                        },
                                                       },
                                             H1 = new H1
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 400,
                                                      FontSize = "56px"
                                                  },
                                             H2 = new H2()
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 375,
                                                      FontSize = "44px"
                                                  },
                                             H3 = new H3()
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 350,
                                                      FontSize = "42px"
                                                  },
                                             H4 = new H4()
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 325,
                                                  },
                                             H5 = new H5()
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 200,
                                                  },
                                             H6 = new H6()
                                                  {
                                                      FontFamily = new string[]
                                                                   {
                                                                       "Cinzel",
                                                                       "serif"
                                                                   },
                                                      FontWeight = 200,
                                                  },
                                             Subtitle1 = new Subtitle1()
                                                         {
                                                             FontFamily = new string[]
                                                                          {
                                                                              "Forum",
                                                                              "serif",
                                                                          },
                                                         },
                                             Subtitle2 = new Subtitle2()
                                                         {
                                                             FontFamily = new string[]
                                                                          {
                                                                              "Forum",
                                                                              "serif",
                                                                          },
                                                         },
                                             Body1 = new Body1()
                                                     {
                                                         FontFamily = new string[]
                                                                      {
                                                                          "Forum",
                                                                          "serif",
                                                                      },
                                                     },
                                             Body2 = new Body2()
                                                     {
                                                         FontFamily = new string[]
                                                                      {
                                                                          "Forum",
                                                                          "serif",
                                                                      },
                                                     },
                                             Button = new Button()
                                                      {
                                                          FontFamily = new string[]
                                                                       {
                                                                           "Forum",
                                                                           "serif",
                                                                       },
                                                      },
                                             Caption = new Caption()
                                                       {
                                                           FontFamily = new string[]
                                                                        {
                                                                            "Forum",
                                                                            "serif",
                                                                        },
                                                       },
                                             Overline = new Overline()
                                                        {
                                                            FontFamily = new string[]
                                                                         {
                                                                             "Forum",
                                                                             "serif",
                                                                         },
                                                        },
                                         },
                            // LayoutProperties = null,
                            // ZIndex = null,
                            // PseudoCss = null
                        };
            return theme;
        }

        public static readonly List<SiteNav> SiteNavigationList = new List<SiteNav>()
                                                                  {
                                                                      new SiteNav
                                                                      {
                                                                          Icon = Icons.TwoTone.HomeRepairService,
                                                                          Title = "Services",
                                                                      },

                                                                      new SiteNav
                                                                      {
                                                                          Icon = Icons.TwoTone.AttachMoney,
                                                                          Title = "Pricing",
                                                                      },
                                                                      new SiteNav
                                                                      {
                                                                          Icon = Icons.TwoTone.Email,
                                                                          Title = "Contact",
                                                                      },
                                                                      new SiteNav
                                                                      {
                                                                          Icon = Icons.TwoTone.Policy,
                                                                          Title = "Policy",
                                                                      },
                                                                      new SiteNav
                                                                      {
                                                                          Icon = Icons.TwoTone.Info,
                                                                          Title = "About",
                                                                      },
                                                                  };
    }

}