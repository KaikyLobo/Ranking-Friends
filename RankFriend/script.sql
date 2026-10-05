CREATE DATABASE IF NOT EXISTS RankingAmigos;
USE RankingAmigos;

CREATE TABLE IF NOT EXISTS Amigos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Posicao INT NOT NULL
);

INSERT INTO Amigos (Nome, Posicao) VALUES
('João', 1),
('Pedro', 2),
('Lucas', 3),
('Gabriel', 4);