﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    /*
   Arabanın kiralanma bilgisini tutan tablo oluşturunuz. 
        Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), 
    ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır. 
    */
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
