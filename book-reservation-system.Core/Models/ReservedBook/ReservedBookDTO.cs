﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_reservation_system.Core.Models.Book;

namespace book_reservation_system.Core.Models.ReservedBook
{
    public class ReservedBookDTO
    {
        public int Id { get; set; }

        public GetBookDTO Book { get; set; }

        public string Comment { get; set; }
    }
}