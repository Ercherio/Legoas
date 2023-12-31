﻿namespace Client.ViewModels;

public class ListVM<Entity>
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
    public List<Entity>? Data { get; set; }
}
