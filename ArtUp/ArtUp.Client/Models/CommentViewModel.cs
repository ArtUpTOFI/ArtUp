﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class CommentViewModel
    {
        /// <summary>
        /// Text of the comment
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date of publishing
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Name of the author
        /// </summary>
        public string Author { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }
    }
}