using MediatorApp;

ChatRoomMediator mediator = new();

Participant john = new(mediator, "John");
Participant ross = new(mediator, "Ross");

mediator.Register(john);
mediator.Register(ross);

john.Send("Hi there!");
ross.Send("What is up?");
