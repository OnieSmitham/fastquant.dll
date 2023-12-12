﻿using System;
using System.Collections;
using System.Drawing;
using System.Linq;

namespace SmartQuant.Charting
{
    public class TTitleItem
    {
        public string Text { get; set; }

        public Color Color { get; set; }

        public TTitleItem() : this("", Color.Black)
        {
        }

        public TTitleItem(string text) : this(text, Color.Black)
        {
        }

        public TTitleItem(string text, Color color)
        {
            Text = text;
            Color = color;
        }
    }

    public enum ETitleStrategy
    {
        Smart,
        None,
    }

    [Serializable]
    public class TTitle
    {
        private Pad pad;

        public ArrayList Items { get; } = new ArrayList();

        public bool ItemsEnabled { get; set; } = false;

        public string Text { get; set; }

        public Font Font { get; set; } = new Font("Arial", 8f);

        public Color Color { get; set; } = Color.Black;

        public ETitlePosition Position { get; set; } = ETitlePosition.Left;

        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public int Width => (int)this.pad.Graphics.MeasureString(GetText(), Font).Width;

        public int Height => (int)this.pad.Graphics.MeasureString(GetText(), Font).Height;

        public ETitleStrategy Strategy { get; set; } = ETitleStrategy.Smart;

        public TTitle(Pad pad, string text = "")
        {
            this.pad = pad;
            Text = Text;
        }

        public void Add(string text, Color color) => Items.Add(new TTitleItem(text, color));

        private string GetText() => Text + string.Join(" ", Items.Cast<TTitleItem>().Select(i => i.Text));

        public void Paint()
        {
            var brush = new SolidBrush(Color);
            if (!string.IsNullOrEmpty(Text))
                this.pad.Graphics.DrawString(Text, Font, brush, X, Y);
            if (Strategy == ETitleStrategy.Smart && Text == "" && ItemsEnabled && Items.Count != 0)
                this.pad.Graphics.DrawString(((TTitleItem)Items[0]).Text, Font, brush, X, Y);
            if (!ItemsEnabled)
                return;
            string str = Text;
            foreach (TTitleItem item in Items)
            {
                string text = str + " ";
                int num = X + (int)this.pad.Graphics.MeasureString(text, Font).Width;
                this.pad.Graphics.DrawString(item.Text, Font, new SolidBrush(item.Color), num, Y);
                str = text + item.Text;
            }
        }
    }
}
