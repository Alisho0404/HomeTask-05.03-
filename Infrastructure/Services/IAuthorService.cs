using Domain;
namespace Infrastructure; 


public interface IAuthorService
{
    Author GetAuthorByID(int id); 
    void AddAuthor(Author author); 
    void UpdateAuthor(Author author); 
    void DeleteAuthor(int id);  
    List<Author> AllAuthors();

}
