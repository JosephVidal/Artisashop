/* tslint:disable */
/* eslint-disable */
/**
 * API Artichaut
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
  Account,
  Home,
} from '../models';
import {
    AccountFromJSON,
    AccountToJSON,
    HomeFromJSON,
    HomeToJSON,
} from '../models';

export interface ApiBackofficeChangeValidationStatusPatchRequest {
    requestBody?: { [key: string]: string; };
}

/**
 * 
 */
export class BackofficeApi extends runtime.BaseAPI {

    /**
     */
    async apiBackofficeChangeValidationStatusPatchRaw(requestParameters: ApiBackofficeChangeValidationStatusPatchRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/backoffice/changeValidationStatus`,
            method: 'PATCH',
            headers: headerParameters,
            query: queryParameters,
            body: requestParameters.requestBody,
        }, initOverrides);

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiBackofficeChangeValidationStatusPatch(requestParameters: ApiBackofficeChangeValidationStatusPatchRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<string> {
        const response = await this.apiBackofficeChangeValidationStatusPatchRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiBackofficeGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<Account>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/backoffice`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(AccountFromJSON));
    }

    /**
     */
    async apiBackofficeGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<Account>> {
        const response = await this.apiBackofficeGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiBackofficeStatsGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Home>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/backoffice/stats`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => HomeFromJSON(jsonValue));
    }

    /**
     */
    async apiBackofficeStatsGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Home> {
        const response = await this.apiBackofficeStatsGetRaw(initOverrides);
        return await response.value();
    }

}
