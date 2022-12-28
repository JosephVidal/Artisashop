import React from "react";
import { Wrapper, DescSection, WhySection } from "./styles";

interface Props {}

const ProductPres: React.FunctionComponent<Props> = () =>
  <Wrapper>
    <DescSection>
      <div className="text-part">
        <h1>Le goût pour les beaux objets</h1>
        <p>Pièces uniques ou petites séries, du mobilier ou de la faïence vous trouverez toutes sortes d’objets d’art fabriqués à la main par nos artisans qualifiés.</p>
      </div>
      <div id="img-part">
        <div id="img-group">
          <img src="/img/product/buste-romain.JPG" alt="" />
          <img src="/img/product/Applique papier.jpg" alt="" />
        </div>
        <img id="img-solo" src="/img/product/Oeuf de paques.jpg" alt="" />
      </div>
    </DescSection>
    <WhySection>
      <div className="text-part">
        <h1>Pourquoi l’artisanat?</h1>
        <p>Dans un monde où la consommation est la norme, l’obsolescence devient la règle au détriment de la qualité. Chez Artisashop nous voulons valoriser la durabilité et la singularité, en vous proposant des produits uniques et durables issus d’un travail passionné et local. Acheter de artisanat c’est investir dans l’histoire, valoriser un savoir-faire, mais c’est aussi contribuer à une économie locale et durable.</p>
      </div>
    </WhySection>
  </Wrapper>

export default ProductPres;
