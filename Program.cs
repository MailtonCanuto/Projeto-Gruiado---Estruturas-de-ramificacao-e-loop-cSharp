// a matriz ourAnimals armazenará o seguinte:
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variáveis que dão suporte à entrada de dados
int maxPets = 8;
string? readResult;
string menuSelection = "";
int petAge = 0;

// matriz usada para armazenar dados de tempo de execução, não há dados persistentes
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Converter a construção if-elseif-else em uma instrução switch

// criar algumas entradas iniciais da matriz ourAnimals
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Espécie: " + animalSpecies;
    ourAnimals[i, 2] = "Idade: " + animalAge;
    ourAnimals[i, 3] = "Apelido: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Bem-vindo ao aplicativo PetFriends da Contoso. Suas opções de menu principal são:");
    Console.WriteLine();
    Console.WriteLine(" 1. Listar todas as informações atuais sobre animais de estimação");
    Console.WriteLine(" 2. Atribuir valores aos campos da matriz ourAnimals");
    Console.WriteLine(" 3. Verificar se os dados de idade e descrição física dos animais estão completos");
    Console.WriteLine(" 4. Verificar se os dados de apelido e descrição de personalidade dos animais estão completos");
    Console.WriteLine(" 5. Editar a idade do animal");
    Console.WriteLine(" 6. Editar a descrição de personalidade do animal");
    Console.WriteLine(" 7. Exibir todos os gatos com uma característica especificada");
    Console.WriteLine(" 8. Exibir todos os cães com uma característica especificada");
    Console.WriteLine();
    Console.WriteLine("Digite o número da seleção (ou digite Sair para sair do programa)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
    menuSelection = readResult.ToLower();
    }

    /*Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    readResult = Console.ReadLine();*/

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i =0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ");
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }

            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Adicionando outro animal a matrix
            string anotherPet = "y";
            int petCount = 0;
            
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            // Pegar a especie do animal 
            bool validEntry = false;

            do
            {
                Console.WriteLine("\n\rEntre com 'Cachorro' ou 'Gato' para uma nova entrada");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies != "Cachorro" && animalSpecies != "Gato")
                    {
                        Console.WriteLine(animalSpecies);
                        validEntry = false;
                    }
                    else
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);

            // pegar a ID number do animal - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
           
            // criando e validando a idade do animal. 
            do
            {
                Console.WriteLine("Entre com a idade do Pet ou ? para indefinido.");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult;
                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out petAge);
                    }
                    else
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);

            // pegando a descricao fisica do animal
            do
            {
                Console.WriteLine("Entre com a descrição física do animal.");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                    if ((animalPhysicalDescription == ""))
                    {
                        animalPhysicalDescription = "blank";
                    }
                }
            } while (animalPhysicalDescription == "");

            // Pegando a personalidade do pet - animalPersonalityDescription can be blank.
            do
            {
                Console.WriteLine("Entre com a descrição da personalidade do animal.");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPersonalityDescription = readResult.ToLower();
                    if ((animalPersonalityDescription == ""))
                    {
                        animalPersonalityDescription = "blank";
                    }
                }
            } while (animalPersonalityDescription == "");

            // Pegando o apelido do animal. animalNickname can be blank.
            do
            {
                Console.WriteLine("Entre com o apelido do animal.");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();
                    if ((animalNickname == ""))
                    {
                        animalNickname = "blank";
                    }
                }
            } while (animalNickname == "");

            // Armazenando os dados do animal
            ourAnimals[petCount, 0] = "ID #: " + animalID;
            ourAnimals[petCount, 1] = "Especie: " + animalSpecies;
            ourAnimals[petCount, 2] = "Idade: " + animalAge;
            ourAnimals[petCount, 3] = "Apelido: " + animalNickname;
            ourAnimals[petCount, 4] = "Descrição física: " + animalPhysicalDescription;
            ourAnimals[petCount, 5] = "Personalidade: " + animalPersonalityDescription;

            while ((anotherPet == "y") && (petCount < maxPets))
            {
                petCount ++;

                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while ((anotherPet != "y") && (anotherPet != "n"));
                }
             }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            validEntry = false;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 2] == "Age: ?")
                {
                    do
                    {
                        Console.WriteLine($"Please enter the age of {ourAnimals[i, 0]}.");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        ourAnimals[i, 2] = "Age: " + animalAge.ToString();
                    } while (validEntry == false);
                }

                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 4] == "Physical description: ")
                {
                    do
                    {
                        Console.WriteLine($"Please enter the physical description of {ourAnimals[i, 0]} (size, color, gender, weight, housebroken).");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult.ToLower();
                            if (animalPhysicalDescription == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                        }
                    } while (validEntry == false);
                }
            }

            Console.WriteLine("\n\rAge and physical description fields are complete for all of our friends. \n\rPress the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            validEntry = false;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 3] == "Nickname: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalNickname = readResult.ToLower();
                            if (animalNickname == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                }

                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 5] == "Personality: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult.ToLower();
                            if (animalPersonalityDescription == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                }
            }
            Console.WriteLine("\n\rAge and physical description fields are complete for all of our friends. \n\rPress the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal’s age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }


} while (menuSelection != "exit");



