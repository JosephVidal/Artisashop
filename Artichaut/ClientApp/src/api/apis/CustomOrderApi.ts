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
  Billing,
  ProblemDetails,
} from '../models';
import {
    BillingFromJSON,
    BillingToJSON,
    ProblemDetailsFromJSON,
    ProblemDetailsToJSON,
} from '../models';

export interface CustomOrderPostRequest {
    billing?: Billing;
}

/**
 * 
 */
export class CustomOrderApi extends runtime.BaseAPI {

    /**
     */
    async customOrderGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/custom-order`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async customOrderGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.customOrderGetRaw(initOverrides);
    }

    /**
     */
    async customOrderPostRaw(requestParameters: CustomOrderPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/custom-order`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: BillingToJSON(requestParameters.billing),
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async customOrderPost(requestParameters: CustomOrderPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.customOrderPostRaw(requestParameters, initOverrides);
    }

}
