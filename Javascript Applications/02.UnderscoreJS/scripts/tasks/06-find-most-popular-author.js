define(['tasks/books', 'underscore'], function(books, _){
    var task = 'By a given collection of books, find the most popular author (the author with the highest number of books)',   elements;

    elements = _.map(books, function(book){
        return JSON.stringify(book);
    });

    function findMostPopularAuthor() {
        var groupedAuthors = _.groupBy(books, function(book){
            return book.author;
        });

        var mostPopularAuthor = _.max(groupedAuthors, function(item){
            return item.length;
        });

        return 'Most popular autor is ' + mostPopularAuthor[0].author
            + ' with ' + mostPopularAuthor.length + ' books.';
    }

    return {
        task: task,
        elements: elements,
        execute: findMostPopularAuthor
    }
});