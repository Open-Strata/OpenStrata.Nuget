// Copyright (c) 74Bravo LLC and Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project or repository root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenStrata.Xml
{
    public class CustomXElement : XElement
    {
        public CustomXElement(XElement copyFrom) : base(copyFrom)
        {
            this.ReplaceElement(copyFrom);
        }

        public CustomXElement(XName name) : base(name)
        {
        }
    }
}
