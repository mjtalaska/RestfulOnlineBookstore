insert into People (Name, Surname, DateOfBirht, Discriminator) values ('Stephen', 'King', '1946-12-24', 'Author')
insert into People (NAme, Surname, DateOfBirht, Discriminator) values ('Maruyama', 'Kagune', '1990-03-12', 'Author')

insert into Language (Name) values ('English')

insert into Genres(Name) values ('Horror')
insert into Genres (Name) values ('Fantasy')
insert into Genres (Name) values ('Thriller')
insert into Genres (Name) values ('Detective')
insert into Genres (Name) values ('Science Fiction')

insert into BookType (Name) values ('Book')

insert into Status (Name) values ('Available')
insert into Status (Name) values ('Unavailable')

insert into Series (Name) values ('Overlord')

insert into Books (Title, Year, Amount, Price, Cover, PublisherId, StatusId, OriginalLanguageLanguageId) values ('IT', 2002, 120, 29.99, 'https://m.media-amazon.com/images/I/712+f2W4uoL._AC_UF1000,1000_QL80_.jpg', 1, 1, 2)
insert into Books (Title, Year, Amount, Price, Cover, PublisherId, StatusId, OriginalLanguageLanguageId) values ('Carrie', 1998, 56, 24.99, 'https://cdn.kobo.com/book-images/36c33e57-6f48-43f5-ba3a-0d60d82e4308/353/569/90/False/carrie-2.jpg', 1, 1, 2)

insert into AuthorBook (AuthorsPersonId, BooksBookId) values (1, 1)
insert into AuthorBook (AuthorsPersonId, BooksBookId) values (1, 2)

insert into BookGenre (GenresGenreId, BooksBookId) values (1, 1)
insert into BookGenre (GenresGenreId, BooksBookId) values (1, 2)

insert into BookBookType (TypeBookTypeId, BooksBookId) values (1, 1)
insert into BookBookType (TypeBookTypeId, BooksBookId) values (1, 2)