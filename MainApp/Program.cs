using Domain;
using Infrastructure;

var author1=new Author();  
author1.Id=1;
author1.FirstName="Stive"; 
author1.LastName="Jobs"; 
author1.Nationality="USA"; 
author1.BirthDate=new DateTime(1950,12,05);  
author1.Books=new List<Book>();

var author2=new Author();  
author2.Id=2;
author2.FirstName="Hal"; 
author2.LastName="Elrod"; 
author2.Nationality="USA"; 
author2.BirthDate=new DateTime(1970,11,02);  
author2.Books=new List<Book>();

var author3=new Author();  
author3.Id=3;
author3.FirstName="Abulqosim"; 
author3.LastName="Firdavsi"; 
author3.Nationality="Tajikistan"; 
author3.BirthDate=new DateTime(970,05,03); 
author3.Books=new List<Book>();


var book1=new Book(); 
book1.Id=1; 
book1.Title="The Innovation Secrets of Steve Jobs"; 
book1.Description="Bestseller for 2 years"; 
book1.PublicationYear=new DateTime(2005,09,05); 
book1.PageSize=350; 
book1.Price=380; 
book1.AuthorId=1; 

var book2=new Book(); 
book2.Id=2; 
book2.Title="Miracle morning"; 
book2.Description="Book which were translated to 24 language"; 
book2.PublicationYear=new DateTime(2009,05,05); 
book2.PageSize=300; 
book2.Price=400; 
book2.AuthorId=2;  

var book3=new Book(); 
book3.Id=3; 
book3.Title="Shohnoma"; 
book3.Description="Historical book"; 
book3.PublicationYear=new DateTime(2001,12,25); 
book3.PageSize=600; 
book3.Price=500; 
book3.AuthorId=3; 

var book4=new Book(); 
book4.Id=4; 
book4.Title="Layli and Majnun"; 
book4.Description="Romantic poem"; 
book4.PublicationYear=new DateTime(2001,12,25); 
book4.PageSize=600; 
book4.Price=500; 
book4.AuthorId=3;  

author1.Books.Add(book1);
author2.Books.Add(book2); 
author3.Books.Add(book3); 
author3.Books.Add(book4);  

var authorservice=new AuthorService();  
authorservice.AddAuthor(author1); 
authorservice.AddAuthor(author2); 
authorservice.AddAuthor(author3);  
System.Console.WriteLine();


var bookService =new BookService(); 
bookService.AddBook(book1);  
bookService.AddBook(book2); 
bookService.AddBook(book3); 
bookService.AddBook(book4);  
System.Console.WriteLine(); 

var authorFilters=new AuthorFilters();
authorFilters.FullName="Firdavsi"; 
authorFilters.BirthYear=970; 
authorFilters.Nationality="Tajikistan";  

foreach (var item in authorservice.AllAuthors())
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.FirstName);
    System.Console.WriteLine(item.LastName);
    System.Console.WriteLine(item.BirthDate);
    System.Console.WriteLine(item.Nationality); 
    System.Console.WriteLine();
    foreach (var book in bookService.GetBooksByAuthor(item.Id))
    {
        System.Console.WriteLine("\u2022 "+book.Title);
    }
    System.Console.WriteLine("----------------------------------------------");
}
System.Console.WriteLine();
System.Console.WriteLine("List filtered authors");
System.Console.WriteLine();

foreach (var item in authorservice.GetAuthors(authorFilters))
{
  System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.FirstName);
    System.Console.WriteLine(item.LastName);
    System.Console.WriteLine(item.BirthDate);
    System.Console.WriteLine(item.Nationality); 
    System.Console.WriteLine();
    foreach (var book in bookService.GetBooksByAuthor(item.Id))
    {
        System.Console.WriteLine("\u2022 "+book.Title);
    }
    System.Console.WriteLine("----------------------------------------------");  
}  

var bookFilters=new BookFilters();
bookFilters.Price=200;  
System.Console.WriteLine("Books which price is above 200 somoni");
foreach (var item in bookService.GetBook(bookFilters))
{
    System.Console.WriteLine(item.Title);
    System.Console.WriteLine(item.PublicationYear);
     System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
}






