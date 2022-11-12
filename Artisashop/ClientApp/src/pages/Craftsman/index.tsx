import React, { useEffect, useMemo, useState } from "react";
import { useParams } from "react-router-dom";
import { Account } from "api/models/Account";
import ProductCard from "components/ProductCard";
import { Wrapper, ProductsList } from "./styles";

const CraftsmanView = () => {
  const { id } = useParams();
  const [account, setProduct] = useState<Account | null>(null);
  // const craftsmantImg = useMemo(() => account?.images ? `/img/product/${account?.images[0]}` : "/img/product/default.png", [account]);
  const craftsmanLastname = useMemo(() => account?.lastname, [account]);
  const craftsmanJob = useMemo(() => account?.job, [account]);
  // const craftsmanDescription = useMemo(() => account?.description, [account]);
  // const craftsmanAddress = useMemo(() => account?.adress, [account]);
  const craftsmanProducts = useMemo(() => account?.products, [account]);

  useEffect(() => {
    if (id) {
      fetch(`/api/craftsman/info/${id}`)
      .then(response => response.json())
      .then(data => setProduct(data as Account));
    }
  }, [id]);

  return (
    <Wrapper>
      <section>
        <div>
          <img src="img/craftsman/Joseph.jpg" alt="" />
          <div id="craftsman">
            <h1>{craftsmanLastname}Joseph Vidal</h1>
            <p id="job">{craftsmanJob}Ébéniste</p>
          </div>
          <span className="tag">Test</span>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. In, fugiat eaque, veniam doloremque suscipit velit nihil ducimus assumenda obcaecati consequatur vero quas id pariatur officiis dignissimos eos, reiciendis accusantium rem!</p>
        </div>
      </section>
      <ProductsList>
        {craftsmanProducts?.map(elem => <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name={elem.name} price={elem.price} />)}
      </ProductsList>
    </Wrapper>
  )
};

export default CraftsmanView;