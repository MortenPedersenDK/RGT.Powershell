﻿using System;
using System.Collections.Generic;

namespace RGT.Services.Core.DTO
{
    public class Segment : IEquatable<Segment>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SegmentResult>  Results { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            if(obj is Segment == false) return false;
            return (obj as Segment).Id == Id;
        }

        public bool Equals(Segment other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
