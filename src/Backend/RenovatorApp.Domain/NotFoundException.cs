namespace RenovatorApp.Domain;

public class NotFoundException(string message) : Exception(message);
