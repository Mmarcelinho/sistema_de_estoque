namespace Estoque.Domain.Entities.Shared;

    public abstract class Entity
    {
        public int Id { get; protected set; }
    }


/*
Classe base que obriga todas as entidades a possuir um Id
*/