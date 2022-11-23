import React, {useEffect, useMemo, useState} from "react";
import {useParams} from "react-router-dom";
import {Account} from "api/models/Account";
import {Product} from "api/models/Product";
import ProductCard from "components/ProductCard";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import {Wrapper, ProductsList, Craftsman} from "./styles";
import useApi from "../../hooks/useApi";
import {AccountApi, ProductApi} from "../../api";

const CraftsmanView = () => {
  const { id } = useParams();
  const [account, setAccount] = useState<Account | null>(null);
  const [products, setProducts] = useState<Product[] | null>(null);
  const accountApi = useApi(AccountApi);
  const productApi = useApi(ProductApi);
  const craftsmantImg = useMemo(() => account?.profilePicture ? `/img/craftsman/${account?.profilePicture}` : "/img/craftsman/default.svg", [account]);
  const craftsmanFirstname = useMemo(() => account?.firstname, [account]);
  const craftsmanLastname = useMemo(() => account?.lastname, [account]);
  const craftsmanJob = useMemo(() => account?.job, [account]);
  const craftsmanDescription = useMemo(() => account?.biography, [account]);
  const craftsmanAddress = useMemo(() => account?.address, [account]);
  const craftsmanProducts = useMemo(() => products, [products]);

  useEffect(() => {
    const update = async () => {
      if (id) {
        const result = await accountApi.apiAccountIdGet({id});
        setAccount(result.account ?? null);
      }
    }
    const getProducts = async () => {
      if (id) {
        const result = await productApi.apiProductGet({sellerId: id});
        setProducts(result ?? null);
      }
    }
    update();
    getProducts();
  }, [id]);

  useFormattedDocumentTitle((craftsmanFirstname && craftsmanLastname) ? `${craftsmanFirstname} ${craftsmanLastname}`  : "Artisan");

  return (
    <Wrapper>
      <section>
        <Craftsman>
          <img src={craftsmantImg} alt=""/>
          <div id="craftsman">
            <h1>{craftsmanFirstname} {craftsmanLastname}</h1>
            <p id="job">{craftsmanJob}</p>
            <p>{craftsmanAddress}</p>
          </div>
        </Craftsman>
        <p id="bio">{craftsmanDescription}</p>
      </section>
      <ProductsList>
        {craftsmanProducts?.map(elem => (
          <ProductCard
            // TODO: Use image.content instead of image.imagePath
            img={elem.productImages?.at(0)?.imagePath || "/img/product/default.png"} serie="Petite série"
            name={elem.name}
            price={elem.price}
            href={`/app/product/${elem?.id}`}
            productStyles={elem?.productStyles}
          />
        ))}
      </ProductsList>
    </Wrapper>
  );
};

export default CraftsmanView;
