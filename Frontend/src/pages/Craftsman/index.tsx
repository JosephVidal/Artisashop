import React, {useEffect, useMemo, useState} from "react";
import {useParams, useNavigate, Link} from "react-router-dom";
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
  const navigate = useNavigate();
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
            <div id="craftsman-name-section">
              <h1>{craftsmanFirstname} {craftsmanLastname}</h1>
              <Link to={`/chat/${account?.id ?? ''}`} className="chat-button">💬</Link>
            </div>
            <p id="job">{craftsmanJob}</p>
            <p>{craftsmanAddress}</p>
          </div>
        </Craftsman>
        <p id="bio">{craftsmanDescription}</p>
      </section>
      <ProductsList>
        {craftsmanProducts?.map(product => (
          <ProductCard
            img={product.productImages?.at(0)?.content ?? `/img/product/${product.productImages?.at(0)?.imagePath || "default.png"}`}
             serie="Petite série"
            name={product.name}
            price={product.price}
            href={`/product/${product?.id}`}
            productStyles={product?.productStyles}
          />
        ))}
      </ProductsList>
    </Wrapper>
  );
};

export default CraftsmanView;
