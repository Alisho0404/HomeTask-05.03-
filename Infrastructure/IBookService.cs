using Domain;
namespace Infrastructure;

public interface IBookService
{
List<Book> AllBooks();  
List<Book> GetBooksByAuthor(int authorID);
void UpdateBook(Book book); 

void AddBook(Book book); 
void DeleteBook(int id);
}
