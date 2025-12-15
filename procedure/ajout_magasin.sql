
CREATE PROCEDURE ajout_magasin
	@libelle varchar(255)
AS
BEGIN
	insert into Commande(libelleMagasin)
	values (@libelle)
END
GO
