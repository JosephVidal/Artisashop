import React from "react";
import { CraftsmanCardWrapper } from "./styles";

interface Props {
  name: string;
  job: string;
  img: string;
  description: string;
  href: string;
}

const CraftsmanCard: React.FunctionComponent<Props> = ({
  name,
  job,
  img,
  description,
  href,
}) => (
  <CraftsmanCardWrapper>
    <a href={href}>
      <div id="card">
        <div id="card-header">
          <img src={img} alt="" />
          <div>
            <p id="craftsman-name">{name}</p>
            <p id="craftsman-job">{job}</p>
          </div>
        </div>
        <p id="craftsman-description">{description}</p>
      </div>
    </a>
  </CraftsmanCardWrapper>
);

export default CraftsmanCard;
