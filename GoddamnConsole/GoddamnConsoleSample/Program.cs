﻿using System.Linq;
using GoddamnConsole.Controls;
using GoddamnConsole.Drawing;
using Console = GoddamnConsole.Console;

namespace GoddamnConsoleSample
{
    internal class Program
    {
        private const string Lorem =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magn" +
            "a aliqua. Ut enim ad minim veniam, quis nostrud exercitat" +
            "ion ullamco laboris nisi ut aliquip ex ea commodo consequ" +
            "at. Duis aute irure dolor in reprehenderit in voluptate v" +
            "elit esse cillum dolore eu fugiat nulla pariatur. Excepte" +
            "ur sint occaecat cupidatat non proident, sunt in culpa qu" +
            "i officia deserunt mollit anim id est laborum.";

        private static readonly string LongLorem = string.Join("\n", Enumerable.Repeat(Lorem, 10));

        private static void Main()
        {
            var gridWindowTest = new GridWindow
            {
                Title = "GridWindow Test (Next: Shift+Tab)",
                DrawBorders = true,
                RowDefinitions =
                {
                    new GridSize(GridUnitType.Fixed, 10),
                    new GridSize(GridUnitType.Auto, 0),
                    new GridSize(GridUnitType.Auto, 0),
                },
                ColumnDefinitions =
                {
                    new GridSize(GridUnitType.Grow, 3),
                    new GridSize(GridUnitType.Grow, 2),
                    new GridSize(GridUnitType.Fixed, 15)
                },
                Children =
                {
                    new Border
                    {
                        FrameStyle = FrameStyle.Single,
                        Content = new TextView
                        {
                            Text = "1"
                        },
                        //AttachedProperties =
                        //{
                        //    new GridProperties
                        //    {
                        //        Row = 0,
                        //        Column = 0,
                        //        RowSpan = 3
                        //    }
                        //}
                    },
                    new Border
                    {
                        FrameStyle = FrameStyle.Single,
                        Content = new TextView
                        {
                            Text = "2"
                        },
                        //AttachedProperties =
                        //{
                        //    new GridProperties
                        //    {
                        //        Row = 0,
                        //        Column = 1,
                        //        ColumnSpan = 2
                        //    }
                        //}
                    },
                    new Border
                    {
                        FrameStyle = FrameStyle.Single,
                        Content = new TextView
                        {
                            Text = "3"
                        },
                        //AttachedProperties =
                        //{
                        //    new GridProperties
                        //    {
                        //        Row = 1,
                        //        Column = 1
                        //    }
                        //}
                    },
                    new Border
                    {
                        FrameStyle = FrameStyle.Single,
                        Content = new TextView
                        {
                            Text = "4"
                        },
                        //AttachedProperties =
                        //{
                        //    new GridProperties
                        //    {
                        //        Row = 2,
                        //        Column = 2
                        //    }
                        //}
                    }
                }
            };
            var btn = new Button
            {
                Text = "Press me!",
                Height = ControlSizeType.MaxByContent
            };
            var text = new TextView
            {
                Text = "Click count: 0",
                Height = ControlSizeType.MaxByContent,
                Name = "clkCnt"
            };
            var clkCnt = 0;
            btn.Clicked += (o, e) => ((TextView) btn.ByName("clkCnt")).Text = $"Click count: {++clkCnt}";
            var box = new TextBox
            {
                TextWrapping = TextWrapping.Wrap,
                Text = "Hello World!"
            };
            var view = new TextView
            {
                DataContext = box,
                //AttachedProperties =
                //{
                //    new GridProperties
                //    {
                //        Row = 1
                //    }
                //}
            };
            //view.Bind(nameof(view.Text), "Text");
            var tabControlTest = new ContentWindow
            {
                Title = "ContentWindow + TabControl2 Test (Prev: Shift+Tab)",
                Content = new TabControl
                {
                    Children =
                    {
                        new Tab
                        {
                            Title = "TextView",
                            Content = new TextView
                            {
                                Text = "Read-only text!\n" + LongLorem
                            }
                        },
                        new Tab
                        {
                            Title = "Vertical StackPanel",
                            Content = new StackPanel
                            {
                                Children =
                                {
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #1",
                                                Height = ControlSizeType.MaxByContent
                                            },
                                        Height = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #2",
                                                Height = ControlSizeType.MaxByContent
                                            },
                                        Height = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #3",
                                                Height = ControlSizeType.MaxByContent
                                            },
                                        Height = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #4",
                                                Height = ControlSizeType.MaxByContent
                                            },
                                        Height = ControlSizeType.MaxByContent
                                    }
                                }
                            }
                        },
                        new Tab
                        {
                            Title = "Horizontal StackPanel",
                            Content = new StackPanel
                            {
                                Orientation = StackPanelOrientation.Horizontal,
                                Children =
                                {
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #1",
                                                Width = ControlSizeType.MaxByContent
                                            },
                                        Width = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #2",
                                                Width = ControlSizeType.MaxByContent
                                            },
                                        Width = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #3",
                                                Width = ControlSizeType.MaxByContent
                                            },
                                        Width = ControlSizeType.MaxByContent
                                    },
                                    new Border
                                    {
                                        Content =
                                            new TextView
                                            {
                                                Text = "Item #4",
                                                Width = ControlSizeType.MaxByContent
                                            },
                                        Width = ControlSizeType.MaxByContent
                                    }
                                }
                            }
                        },
                        new Tab
                        {
                            Title = "ScrollViewer",
                            Content = new ScrollViewer
                            {
                                Content = new TextView
                                {
                                    Text = LongLorem,
                                    TextWrapping = TextWrapping.Wrap,
                                    Height = ControlSizeType.MaxByContent
                                }
                            }
                        },
                        new Tab
                        {
                            Title = "TextBox + Binding",
                            Content = new Grid
                            {
                                RowDefinitions =
                                {
                                    new GridSize(GridUnitType.Grow, 1),
                                    new GridSize(GridUnitType.Grow, 1)
                                },
                                Children =
                                {
                                    box,
                                    view
                                }
                            }
                        },
                        new Tab
                        {
                            Title = "Button",
                            Content = new StackPanel
                            {
                                Children =
                                {
                                    new TextView
                                    {
                                        Text = "Press that",
                                        Height = ControlSizeType.MaxByContent
                                    },
                                    btn,
                                    text
                                }
                            }
                        }
                    },
                    SelectedIndex = 0
                }
            };
            Console.Windows.Add(gridWindowTest);
            Console.Windows.Add(tabControlTest);
            Console.Start();
        }
    }
}
