function detalhes( item )
	{
		let descricao = "";
		if ( item.id == "nome" ) { descricao = "seu nome completo sem abreviações."; }
		if ( item.id == "nomemusica" ) { descricao = "o nome completo da música sem abreviações."; }
		if ( item.id == "nomealbum" ) { descricao = "o nome completo do álbum sem abreviações."; }
		if ( item.id == "nomeartista" ) { descricao = "o nome completo sem abreviações."; }
		if ( item.id == "nomegenero" ) { descricao = "o nome do gênero."; }
		if ( item.id == "musica" ) { descricao = "a música da gravação."; }
		if ( item.id == "album" ) { descricao = "o álbum que contém a música."; }
		if ( item.id == "biografia" ) { descricao = "a biografia do Artista."; }
		if ( item.id == "letra" ) { descricao = "a letra completa da música"; }
		if ( item.id == "telefone" ) { descricao = "seu número de telefone completo incluindo DDD."; }
		if ( item.id == "email" ) { descricao = "seu melhor e-mail."; }
		if ( item.id == "datanascimento" ) { descricao = "sua data de nascimento."; }
		if ( item.id == "datalancamento" ) { descricao = "a data de lançamento."; }
		if ( item.id == "duracao" ) { descricao = "a duração da gravação."; }
		if ( item.id == "artista" ) { descricao = "o artista que produziu."; }
		if ( item.id == "senha" ) { descricao = "uma senha forte e segura."; }
		if ( item.id == "genero" ) { descricao = "o gênero da música."; }
		if ( item.id == "generosexual" ) { descricao = "seu gênero sexual."; }
		alert("Insira "+descricao);
	}