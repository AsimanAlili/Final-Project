using Final_Project.Sturucture.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Sturucture.Models
{
    public class OrderItem
    {
        private int _count;
        public MenuItem MenuItem { get; set; }
        public int Count 
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 0)
                   this._count =value ;
                throw new OrderItemModelInvalidException("Count", "Count  can not be less than zero!");
            }
        }
    }
}
