﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lime.Messaging.Contents;
using Lime.Protocol;
using Newtonsoft.Json;
using Octokit;
using Take.Blip.Client;


namespace Api.Services
{
    public class CarroselService
    {
        JsonDocument jsonDocuments;
        JsonDocument jsonDocuments2;
        JsonDocument jsonDocuments3;


        public string CreateCarrosel(IEnumerable<Repository> fiveOlderCSharpRepositories)
        {
            jsonDocuments = new JsonDocument();
            jsonDocuments2 = new JsonDocument();
            jsonDocuments3 = new JsonDocument();

            jsonDocuments.Add("Key1", "value1");
            jsonDocuments.Add("Key2", "2");

            jsonDocuments2.Add("Key3", "value3");
            jsonDocuments2.Add("Key4", "4");

            jsonDocuments3.Add("Key5", "value5");
            jsonDocuments3.Add("Key6", "6");

            DocumentSelect[] documents = new DocumentSelect[]
            {
                new DocumentSelect
                {
                    Header = new DocumentContainer
                    {
                        Value = new MediaLink
                        {
                            Title = "Title",
                            Text = "This is a first item",
                            Type = "image/jpeg",
                            Uri = new Uri("http://www.isharearena.com/wp-content/uploads/2012/12/wallpaper-281049.jpg"),
                        }
                    },
                    Options = new DocumentSelectOption[]
                    {
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new WebLink
                                {
                                    Title = "Link",
                                    Uri = new Uri("http://www.adoteumgatinho.org.br/")
                                }
                            }
                        },
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new PlainText
                                {
                                    Text = "Text 1"
                                }
                            },
                            Value = new DocumentContainer
                            {
                                Value = jsonDocuments
                            }
                        }
                    }
                },
                new DocumentSelect
                {
                    Header = new DocumentContainer
                    {
                        Value = new MediaLink
                        {
                            Title = "Title 2",
                            Text = "This is another item",
                            Type = "image/jpeg",
                            Uri = new Uri("http://www.freedigitalphotos.net/images/img/homepage/87357.jpg")
                        }
                    },
                    Options = new DocumentSelectOption[]
                    {
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new WebLink
                                {
                                    Title = "Second link",
                                    Text = "Weblink",
                                    Uri = new Uri("https://pt.dreamstime.com/foto-de-stock-brinquedo-pl%C3%A1stico-amarelo-do-pato-image44982058")
                                }
                            }
                        },
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new PlainText {
                                    Text = "Second text"
                                }
                            },
                            Value = new DocumentContainer
                            {
                                Value = jsonDocuments2
                            }
                        },
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new PlainText {
                                    Text = "More one text"
                                }
                            },
                            Value = new DocumentContainer
                            {
                                Value = jsonDocuments3
                            }
                        }
                    }
                }

            };


            var document = new DocumentCollection
            {
                ItemType = "application/vnd.lime.document-select+json",
                Items = documents,
            };

            return JsonConvert.SerializeObject(document);
        }
    }
}