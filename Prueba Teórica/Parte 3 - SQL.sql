-- personas que no tienen segundo nombre, pero si tienen segundo apellido
SELECT p.Identificacion,
       p.Sexo,
       p.PrimerNombre,
       p.SegundoNombre,
       p.PrimerApellido,
       p.SegundoApellido,
       p.IdPadre,
       p.IdMadre
FROM Personas p
WHERE p.SegundoNombre IS NULL
  AND p.SegundoApellido IS NOT NULL;
  
-- Consulta de Personas cuyo padre se llama Pedro
SELECT p.Identificacion,
       p.Sexo,
       p.PrimerNombre,
       p.SegundoNombre,
       p.PrimerApellido,
       p.SegundoApellido,
       p.IdPadre,
       p.IdMadre
FROM Personas p
         INNER JOIN Personas p2
                    ON p.IdPadre = p2.Identificacion AND trim(upper(p2.PrimerNombre)) = trim(upper('Pedro'));


-- Número de personas por año de nacimiento
SELECT COUNT(DATE_FORMAT(p.FechaNacimiento, '%Y')) AS Cantidad,
       DATE_FORMAT(p.FechaNacimiento, '%Y')        AS AnioNacimiento
FROM Personas p
GROUP BY DATE_FORMAT(p.FechaNacimiento, '%Y');

-- Consulta de toda la tabla que muestre además la edad en meses de la persona en una nueva columna.
SELECT p.Identificacion,
       p.Sexo,
       p.PrimerNombre,
       p.SegundoNombre,
       p.PrimerApellido,
       p.SegundoApellido,
       p.IdPadre,
       p.IdMadre,
       p.FechaNacimiento,
       TIMESTAMPDIFF(MONTH, p.FechaNacimiento, CURDATE()) AS EdadMeses
FROM Personas p

-- La cantidad de madres que tiene más de 5 hijos
SELECT p.Identificacion,
       p.PrimerNombre,
       p.SegundoNombre,
       p.PrimerApellido,
       p.SegundoApellido
FROM Personas p
WHERE p.Identificacion IN (
    SELECT A.IdMadre
    FROM (
             SELECT p.IdMadre,
                    COUNT(p.IdMadre) AS Hijos
             FROM Personas p
                      INNER JOIN Personas p2
                                 ON p.IdMadre = p2.Identificacion
             GROUP BY p.IdMadre
             HAVING Hijos > 5) AS A
)