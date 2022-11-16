import React from "react";

import {Link} from "react-router-dom";

import { FooterWrapper } from "./styles";

interface Props {}

const Footer: React.FunctionComponent<Props> = () => (
  <FooterWrapper>
    <footer>
      <div id="up">
        <a href="#top">Haut de la page 👆🏼</a>
      </div>
      <div id="newsletter">
        <p>10% avec la newsletter Artisashop</p>
        <label>
          <input type="email" className="newsletter" placeholder="Votre email"/>
        </label>
      </div>
      <div id="foot-content">
        <div>
          <h3>A propos</h3>
          <a href="/">L&apos;équipe</a>
          <a href="/">Nous rejoindre</a>
           <Link to="/app/admin">Portail modérateur</Link> 
        </div>
        <div>
          <h3>Boutique</h3>
          <a href="/">Les créateurs</a>
          <a href="/">Leur créations</a>
          <a href="/">S&apos;inscrire</a>
        </div>
        <div>
          <h3>Aide</h3>
          <a href="/">FAQ</a>
          <a href="/contact">Nous contacter</a>
          <a href="/politique-de-confidentialite">Politique de confidentialité</a>
        </div>
      </div>
      <div id="links">
        <div id="social">
          <a href="/">
            <svg data-name="Groupe 99" xmlns="http://www.w3.org/2000/svg" width="22.073" height="21.092" viewBox="0 0 22.073 21.092">
              <path id="linkedin" d="M49.141,36.9v8.162H44.409V37.447c0-1.912-.683-3.218-2.4-3.218a2.588,2.588,0,0,0-2.427,1.73,3.239,3.239,0,0,0-.157,1.153v7.949H34.7s.064-12.9,0-14.232h4.733v2.017c-.01.016-.023.031-.031.047h.031v-.047A4.7,4.7,0,0,1,43.693,30.5c3.113,0,5.447,2.034,5.447,6.4ZM29.746,23.969a2.466,2.466,0,1,0-.062,4.918h.031a2.467,2.467,0,1,0,.031-4.918Zm-2.4,21.092h4.73V30.829h-4.73Z" transform="translate(-27.068 -23.969)"/>
            </svg>
          </a>
          <a href="https://www.facebook.com/Artisashop-101955455742650">
            <svg xmlns="http://www.w3.org/2000/svg" width="11.238" height="22.415" viewBox="0 0 11.238 22.415">
              <path id="facebook" data-name="Tracé 31" d="M117.486,76.814h2.889V72.547h-3.4v.015c-4.115.146-4.958,2.459-5.032,4.888h-.008v2.131h-2.8V83.76h2.8v11.2h4.222V83.76h3.459l.668-4.179h-4.126V78.294A1.376,1.376,0,0,1,117.486,76.814Z" transform="translate(-109.136 -72.547)" fill="#f9ece2"/>
            </svg>
          </a>
          <a href="/">
            <svg id="XMLID_13_" xmlns="http://www.w3.org/2000/svg" width="23.124" height="23.124" viewBox="0 0 23.124 23.124">
              <path className="instagram" id="XMLID_17_" d="M16.235,0H6.889A6.9,6.9,0,0,0,0,6.889v9.347a6.9,6.9,0,0,0,6.889,6.889h9.347a6.9,6.9,0,0,0,6.889-6.889V6.889A6.9,6.9,0,0,0,16.235,0ZM20.8,16.235A4.563,4.563,0,0,1,16.235,20.8H6.889a4.563,4.563,0,0,1-4.563-4.563V6.889A4.563,4.563,0,0,1,6.889,2.326h9.347A4.563,4.563,0,0,1,20.8,6.889v9.347Z" fill="#f9ece2"/>
              <path className="instagram" id="XMLID_81_" d="M138.981,133a5.981,5.981,0,1,0,5.981,5.981A5.988,5.988,0,0,0,138.981,133Zm0,9.635a3.654,3.654,0,1,1,3.654-3.654A3.654,3.654,0,0,1,138.981,142.635Z" transform="translate(-127.419 -127.419)" fill="#f9ece2"/>
              <circle className="instagram" id="XMLID_83_" cx="1.433" cy="1.433" r="1.433" transform="translate(16.121 4.193)" fill="#f9ece2"/>
            </svg>
          </a>
        </div>
        <p>Artisashop 2022</p>
        <span/>
      </div>
    </footer>
  </FooterWrapper>
);

export default Footer;
