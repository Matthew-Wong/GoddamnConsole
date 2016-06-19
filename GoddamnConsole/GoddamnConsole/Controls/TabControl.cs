﻿using System;
using System.Collections.Generic;
using System.Linq;
using GoddamnConsole.Drawing;

namespace GoddamnConsole.Controls
{
    public class TabControl : ChildrenControl
    {
        public TabControl()
        {
            Focusable = true;
        }

        public override IList<Control> FocusableChildren
            => SelectedTab == null ? new Control[0] : new Control[] {SelectedTab};

        public override Size MeasureBoundingBox(Control child)
        {
            return child == SelectedTab?.Content 
                ? new Size(0, 0) 
                : new Size(ActualWidth - 2, ActualHeight - 4);
        }
        
        protected override void OnKeyPress(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                var index = Children.IndexOf(SelectedTab);
                if (index < 1) index = 1;
                index--;
                if (Children.Count <= index) return;
                SelectedTab = (Tab) Children[index];
                Invalidate();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                var index = Children.IndexOf(SelectedTab);
                index++;
                if (Children.Count <= index) return;
                SelectedTab = (Tab) Children[index];
                Invalidate();
            }
        }

        public override void Render(DrawingContext context)
        {
            var style = Console.Focused == this
                            ? "║╠╣╩═╦"
                            : "│├┤┴─┬";
            var wpt = (ActualWidth - 1) / Children.Count - 1;
            if (wpt < 2) return;
            var li = Math.Max(ActualWidth - (wpt + 1) * Children.Count - 1, 0);
            var headerLine = style[0] + string.Concat(Children.Cast<Tab>().Select((x, i) =>
            {
                var padded = x.Name.PadLeft(x.Name.Length + 2);
                if (padded.Length > wpt - 4) padded = padded.Remove(wpt - 2);
                return padded.PadRight(wpt + (i == 0 ? li : 0)) + style[0];
            }));
            context.DrawFrame(new Rectangle(0, 0, ActualWidth, ActualHeight), 
                new FrameOptions
                {
                    Style = Console.Focused == this ? FrameStyle.Double : FrameStyle.Single
                });
            context.DrawText(new Point(0, 1), headerLine);
            context.DrawText(new Point(1, 2), new string(style[4], ActualWidth - 2));
            context.PutChar(new Point(0, 2), style[1], CharColor.White, CharColor.Black, CharAttribute.None);
            context.PutChar(new Point(ActualWidth - 1, 2), style[2], CharColor.White, CharColor.Black, CharAttribute.None);
            for (var i = 1; i < Children.Count; i++)
            {
                context.PutChar(new Point(li + i * (wpt + 1), 0), style[5], CharColor.White, CharColor.Black, CharAttribute.None);
                context.PutChar(new Point(li + i * (wpt + 1), 2), style[3], CharColor.White, CharColor.Black, CharAttribute.None);
            }
            if (SelectedTab != null && Children.Contains(SelectedTab))
            {
                var index = Children.IndexOf(SelectedTab);
                var padded = SelectedTab.Name.PadLeft(SelectedTab.Name.Length + 2);
                if (padded.Length > wpt - 4) padded = padded.Remove(wpt - 2);
                padded = padded.PadRight(wpt + (index == 0 ? li : 0));
                context.DrawText(new Point(1 + (index > 0 ? li : 0) + index * (wpt + 1), 1), padded, new TextOptions
                {
                    Background = CharColor.White,
                    Foreground = CharColor.Black
                });
            }
            SelectedTab?.Content?.Render(context.Shrink(new Rectangle(1, 3, ActualWidth - 2, ActualHeight - 4)));
        }

        public Tab SelectedTab
        {
            get { return _selectedTab; }
            set { _selectedTab = value;
                OnPropertyChanged();
            }
        }
        
        private Tab _selectedTab;
    }

    public class Tab : ContentControl
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged();
            }
        }

        public override Size MeasureBoundingBox(Control child)
        {
            return new Size(ActualWidth, ActualHeight);
        }
    }
}
