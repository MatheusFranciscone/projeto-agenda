create database Agenda;

use Agenda;

create table tbcontato(
		codcontato int not null primary key auto_increment
        , nome varchar(100)
        , telefone varchar(14)
        , celular varchar(14)
        , email varchar(50)
);

INSERT INTO tbcontato(nome, telefone, celular, email) VALUES ('Mariana Ferreira', '11 5656-4646', '11 95656-4747', 'marianaf2000@hotmail.com');

select * from tbcontato;