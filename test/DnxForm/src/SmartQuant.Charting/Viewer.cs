﻿using System;
using System.Collections.Generic;

namespace SmartQuant.Charting
{
    public class Viewer
    {
        protected Dictionary<object, List<Property>> metadata = new Dictionary<object, List<Property>>();

        public Type Type { get; set; }

        public virtual bool IsZoomable { get; }

        public virtual PadRange GetPadRangeX(object obj, Pad pad) => null;

        public virtual PadRange GetPadRangeY(object obj, Pad pad) => null;

        public virtual void Paint(object obj, Pad pad)
        {
            // noop
        }

        public void Set(object obj, string name, object value)
        {
            List<Property> list;
            if (!this.metadata.TryGetValue(obj, out list))
            {
                list = new List<Property>();
                this.metadata[obj] = list;
            }
            list.Add(new Property(name, value));
        }

        protected class Property
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public Property(string name, object value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
