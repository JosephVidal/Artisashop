/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  Home,
} from '../models';
import {
    HomeFromJSON,
    HomeToJSON,
} from '../models';

/**
 * 
 */
export class HomeApi extends runtime.BaseAPI {

    /**
     */
    async apiHomeGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Home>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/home`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => HomeFromJSON(jsonValue));
    }

    /**
     */
    async apiHomeGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Home> {
        const response = await this.apiHomeGetRaw(initOverrides);
        return await response.value();
    }

}
