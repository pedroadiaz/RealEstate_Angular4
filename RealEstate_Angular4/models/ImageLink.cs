using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class ImageLink
    {
        public int ImageLinkId { get; set; }
        public int ParentImageId { get; set; }
        public int ChildImageId { get; set; }
        public int Xposition { get; set; }
        public int Yposition { get; set; }
    }
}
