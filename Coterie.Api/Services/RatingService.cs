using Coterie.Api.Data;
using Coterie.Api.Extensions;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Services
{
    public class RatingService : IRatingService 
    {
        private const int HAZARD_FACTOR = 4;
        private const decimal PREMIUM_DIVIDER = 1000m;

        public RatingResponse GetRatings(RatingRequest request)
        {
            List<StatePremium> statePremiums = new();

            string businessFinal = HandleBusiness(request.Business);
            string stateFinal = string.Empty;
            decimal premiumFinal;

            foreach (string state in request.States)
            {
                stateFinal = HandleState(state);
                premiumFinal = HandlePremium(stateFinal, businessFinal, request.Revenue);

                StatePremium statePremium = new()
                {
                    Premium = premiumFinal,
                    State = stateFinal
                };

                statePremiums.Add(statePremium);
            }

            RatingResponse response = new()
            {
                Business = businessFinal,
                Revenue = request.Revenue,
                Premiums = statePremiums
            };


            return response;
        }

        private string HandleState(string state)
        {
            string stateAbr = string.Empty;

            bool isStateAbr = RatingDictionary.AbbreviationToState.ContainsKey(state.ToUpper());
            bool isStateFull = RatingDictionary.StateToAbbreviation.ContainsKey(state.ToUpper());

            if (isStateAbr)
            {
                stateAbr = state.ToUpper();
            }
            else if (isStateFull)
            {
                stateAbr = RatingDictionary.StateToAbbreviation[state.ToUpper()];
            }
            else
            {
                KeyNotFoundException ex = new($"{state} is not a valid state.");
                throw ex;
            }

            return stateAbr;
        }

        private string HandleBusiness(string businessRequest)
        {
            string business;

            if (RatingDictionary.BusinessFactors.ContainsKey(StringExtensions.GetFirstLetterToUpper(businessRequest.ToLower())))
            {
                business = StringExtensions.GetFirstLetterToUpper(businessRequest.ToLower());
            }
            else
            {
                KeyNotFoundException ex = new($"{businessRequest} is not a valid business.");
                throw ex;
            }

            return business;
        }

        private decimal HandlePremium(string state, string business, decimal revenue)
        {
            decimal premium;

            if (revenue < 0)
            {
                IndexOutOfRangeException ex = new("Revenue cannot be less than 0");
                throw ex;
            }

            decimal stateFactor = RatingDictionary.StateFactors[state];
            decimal businessFactor = RatingDictionary.BusinessFactors[business];
            decimal basePremium = Math.Round(revenue / PREMIUM_DIVIDER, 0);

            premium = Math.Round(stateFactor * businessFactor * basePremium * HAZARD_FACTOR, 0);

            return premium;
        }
    }
}
