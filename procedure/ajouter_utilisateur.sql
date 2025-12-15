
CREATE PROCEDURE ajouter_utilisateur
	-- Add the parameters for the stored procedure here
	@nom varchar(30),
	@prenom varchar(30),
	@identifiant varchar(30),
	@motdepasse varchar(30),
	@role int,
	@zone int
AS
BEGIN
	if(@zone != -1)
	begin
	insert into Utilisateur(Nom,Prenom,Identifiant,MotDePasse,idRole,codeZone)
	values(@nom,@prenom,@identifiant,@motdepasse,@role,@zone)
	return
	end
	insert into Utilisateur(Nom,Prenom,Identifiant,MotDePasse,idRole,codeZone)
	values(@nom,@prenom,@identifiant,@motdepasse,@role,Null)
	return
END
GO
