
CREATE PROCEDURE Valider_commande
	@idcmd int
AS
BEGIN
	update commande
	set statut = 1 where idCommande = @idcmd
END
GO
