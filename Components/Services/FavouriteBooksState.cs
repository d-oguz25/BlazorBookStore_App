using BlazorBookStore_App.Components.Models;

namespace BlazorBookStore_App.Components.Services
{

    public class FavouriteBooksState
    {
        public List<Book> FavouriteBooks { get; private set; } = new();
        public void AddToFavourite(Book favBook)
        {
            if (!FavouriteBooks.Contains(favBook))
            {
                FavouriteBooks.Add(favBook);

            }

        }
        public void RemoveFromFavourite(Book book)
        {
            if (FavouriteBooks.Contains(book))
            {
                FavouriteBooks.Remove(book);
            }
        }
    }
}
