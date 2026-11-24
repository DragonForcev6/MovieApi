CREATE DATABASE movie_api

USE movie_api;

CREATE TABLE movies
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    director VARCHAR(150) NOT NULL,
    release_year INT NOT NULL,
    CONSTRAINT chk_release_year CHECK (release_year >= 1888)
);

INSERT INTO movies (title, director, release_year)
VALUES
    ('Interstellar', 'Christopher Nolan', 2014),
    ('The Matrix', 'The Wachowskis', 1999),
    ('Inception', 'Christopher Nolan', 2010);

SELECT * FROM movies;

CREATE USER 'movieuser'@'localhost'
IDENTIFIED BY 'byt_till_eget_losenord';

GRANT SELECT, INSERT, UPDATE, DELETE
ON movie_api.*
TO 'movieuser'@'localhost';


