import React from "react";
import { Link } from "react-router-dom";
import { CraftsmanresultCardWrapper } from "./styles";

interface Props {
    name: string;
    img: string;
    job: string;
    href: string;
}

const CraftsmanresultCard: React.FunctionComponent<Props> = ({
    name,
    img,
    job,
    href,
}) => (
  <CraftsmanresultCardWrapper>
    <Link id="craftsman-result-card" to={href}>
      <img src={img} alt="" />
      <div>
        <p id="craftsman-name">{name}</p>
        <p id="craftsman-job">{job}</p>
      </div>
    </Link>
  </CraftsmanresultCardWrapper>
);

export default CraftsmanresultCard;
