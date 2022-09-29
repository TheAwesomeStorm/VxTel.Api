INSERT INTO cities (Id, Name, DddCode)
VALUES
    (1, 'Canoas', 11),
    (2, 'Porto Alegre', 16),
    (3, 'Esteio', 17),
    (4, 'Novo Hamburgo', 18);

insert into dataplans (Id, Name, FreeMinutes)
VALUES
    (1, 'Fale Mais 30', 30),
    (2, 'Fale Mais 60', 60),
    (3, 'Fale Mais 120', 120);

insert into fares (Id, OriginCityId, DestinationCityId, Value)
VALUES
    (1, 1, 2, 1.9),
    (2, 1, 3, 2.9),
    (3, 1, 4, 1.7),
    (4, 2, 1, 2.7),
    (5, 3, 1, 0.9),
    (6, 4, 1, 1.9);