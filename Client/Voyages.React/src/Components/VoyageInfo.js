import { gql, useQuery } from "@apollo/client"

import ClientInfo from "./ClientInfo"
import FileInfo from "./FileInfo"
import ProductInfo from "./ProductInfo"
import {Message} from "./Elements"

const GET_CLIENT_QUERY = gql`
  query Client($name: String, $lastname: String){
    client(name:$name, lastname:$lastname){
      id,
      name,
      lastName,
      address,
      telephone,
      email,
      birthDate,
      file
      {
        type,
        arrivalDate,
        duration,
        flightNumber,
        place,
        price,
        product
        {
          type,
          name,
          description,
          address,
          telephone,
          photoLink
        }
      }
    }
  }
` 

export default function VoyageInfo({name, lastname}) {

    const {
      data,
      loading,
      error
    } = useQuery(GET_CLIENT_QUERY, {
      variables: { name: name, lastname: lastname },
    });
  
    const client = data?.client;
  
    if (loading) 
        return <Message message="Chargement en cours..."/>    

    if (error) 
        return <Message message="Une erreur est survenue lors de la requête."/>    
            
    if(client)
        return (
        <>
            <ClientInfo clientData={client}></ClientInfo>
            
            {client.file &&
                <FileInfo fileData={client.file}></FileInfo>
                
            }
            
            {client.file.product &&
                <ProductInfo productData={client.file.product}></ProductInfo>
                
            }
        </>
        
        )

    return <Message message="Il n'y a aucune information pour le client indiqué."/>
  }