using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace OpenMeteo.protobuf
{
    [ProtoContract]
    public class Geocoding
    {
        [ProtoMember(1)]
        public object[]? Locations { get; set; }

        [ProtoMember(2)]
        public float Generationtime_ms { get; set; }
    }
}
