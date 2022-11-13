import React, {useEffect, useMemo, useState} from "react";
import {useParams} from "react-router-dom";
import {Account} from "api/models/Account";
import ProductCard from "components/ProductCard";
import {Wrapper, ProductsList} from "./styles";
import useApi from "../../hooks/useApi";
import {Product} from "../../api";

const CraftsmanView = () => {
  // const { id } = useParams();
  // const [account, setProduct] = useState<Account | null>(null);
  // // const craftsmantImg = useMemo(() => account?.images ? `/img/product/${account?.images[0]}` : "/img/product/default.png", [account]);
  // const craftsmanLastname = useMemo(() => account?.lastname, [account]);
  // const craftsmanJob = useMemo(() => account?.job, [account]);
  // // const craftsmanDescription = useMemo(() => account?.description, [account]);
  // // const craftsmanAddress = useMemo(() => account?.adress, [account]);
  // const craftsmanProducts = useMemo(() => account?.products, [account]);

  // useEffect(() => {
  //   if (id) {
  //     fetch(`/api/craftsman/info/${id}`)
  //     .then(response => response.json())
  //     .then(data => setProduct(data as Account));
  //   }
  // }, [id]);

  const craftsman: Account = {
    id: "fakeId",
    firstname: "Jean",
    lastname: "Dupont",
    address: "1 rue de la paix",
    biography: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. In, fugiat eaque, veniam doloremque suscipit\n" +
      "            velit nihil ducimus assumenda obcaecati consequatur vero quas id pariatur officiis dignissimos eos,\n" +
      "            reiciendis accusantium rem!",
    job: "Artisan",
    email: "JeanDupont@gmail.com",
  };
  const craftsmanProducts: Product[] = [
    {
      id: 1,
      name: "Product 1",
      description: "Description 1",
      price: 10,
      images: ["default.png"],
      craftsmanId: "fakeID",
      quantity: 10,
      craftsman: {
        id: "fakeID",
        firstname: "John",
        lastname: "Doe",
        job: "Fake job",
        biography: "Fake description",
        address: "Fake address",
      }
    },
    {
      id: 2,
      name: "Product 2",
      description: "Description 2",
      price: 10,
      images: ["default.png"],
      craftsmanId: "fakeID",
      quantity: 10,
      craftsman: {
        id: "fakeID",
        firstname: "John",
        lastname: "Doe",
        job: "Fake job",
        biography: "Fake description",
        address: "Fake address",
      }
    },
    {
      id: 3,
      name: "Product 3",
      description: "Description 3",
      price: 10,
      images: ["default.png"],
      craftsmanId: "fakeID",
      quantity: 10,
      craftsman: {
        id: "fakeID",
        firstname: "John",
        lastname: "Doe",
        job: "Fake job",
        biography: "Fake description",
        address: "Fake address",
      }
    },
    {
      id: 4,
      name: "Product 4",
      description: "Description 4",
      price: 10,
      images: ["default.png"],
      craftsmanId: "fakeID",
      quantity: 10,
      craftsman: {
        id: "fakeID",
        firstname: "John",
        lastname: "Doe",
        job: "Fake job",
        biography: "Fake description",
        address: "Fake address",
      }
    },
  ];

  return (
    <Wrapper>
      <section>
        <div>
          <img src="img/craftsman/Joseph.jpg" alt=""/>
          <div id="craftsman">
            <h1>{craftsman.firstname} {craftsman.lastname}</h1>
            <p id="job">{craftsman.job}</p>
          </div>
          <span className="tag">Test</span>
          <p>
            {craftsman.biography}
          </p>
        </div>
      </section>
      <ProductsList>
        {craftsmanProducts?.map(elem => (
          <ProductCard
            img="img/product/table à thé.jpg" serie="Petite série"
            name={elem.name}
            price={elem.price}
          />
        ))}
      </ProductsList>
    </Wrapper>
  );
};

export default CraftsmanView;
