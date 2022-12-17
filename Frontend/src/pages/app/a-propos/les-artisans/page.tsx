import React from "react";
import { Wrapper, DescSection, WhoSection } from "./styles";

interface Props {}

const CraftsmanPres: React.FunctionComponent<Props> = () =>
  <Wrapper>
    <DescSection>
      <div className="text-part">
        <h1>Le meilleur de l&apos;artisanat</h1>
        <p>Artisashop sélectionne ses artisans grâce à un cahier des charges exigent, pour garantir une qualité et une durabilité des produits. Le profil de chaque artisan est soigneusement examiné par nos équipes avant de confirmer leur inscription.</p>
      </div>
      <div id="img-part">
        <div id="img-group">
          <img src="/img/craftsman/Pierre.jpeg" alt="" />
          <img src="/img/craftsman/Jacques.jpg" alt="" />
        </div>
        <img id="img-solo" src="/img/craftsman/Jean.jpeg" alt="" />
      </div>
    </DescSection>
    <WhoSection>
      <div className="text-part">
        <h1>Qui sont nos artisans?</h1>
        <p>Nos artisans sont avant tout des créateurs. Issus des meilleures écoles ils sauront répondre à vos besoins, et vous proposer les meilleurs produits.</p>
      </div>
    </WhoSection>
  </Wrapper>

export default CraftsmanPres;
