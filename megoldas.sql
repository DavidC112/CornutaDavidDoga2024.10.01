create database pizzeria default character set utf8 collate utf8_hungarian_ci;

--3. feladat--
alter table rendeles add FOREIGN KEY (pizzaid) REFERENCES pizza(id);
alter table rendeles add FOREIGN KEY (cimid) REFERENCES cim(id);

--4. feladat--
alter table cim add INDEX (nev);

--5. feladat--
DELETE from pizza where nev = "Tonhalas" and meret = 22;

--6. feladat--
UPDATE pizza set ar = ar*0.9;

--7. feladat--
SELECT nev, meret from pizza where meret BETWEEN 25 and 50;

--8. feladat--
select COUNT(*) as "rendelések száma" from rendeles inner JOIN cim on rendeles.cimid = cim.id GROUP by cim.utca;

--9. feladat--
select rendeles.szallitas, rendeles.darab, pizza.nev from rendeles inner join pizza on rendeles.pizzaid = pizza.id ORDER by szallitas limit 5;

--10. feladat--
SELECT cim.nev as "Név", COUNT(cimid) as "Rendelések", Sum(pizza.ar) as "Összeg" from pizza inner join rendeles on pizza.id = rendeles.pizzaid inner join cim on rendeles.cimid = cim.id group by 1;

--11. feladat--
SELECT pizza.meret, COUNT(pizza.id) from pizza where nev Like "%Sonkás%" GROUP by 1 having count(pizza.meret > 1);

--12. Feladat--
SELECT pizza.ar *0.9 as "akciós ár", rendeles.id as "Rendelés", pizza.nev as "Pizza" from pizza inner join rendeles on pizza.id = rendeles.pizzaid;