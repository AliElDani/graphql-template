﻿namespace GraphQLSample.Core.Domains
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
