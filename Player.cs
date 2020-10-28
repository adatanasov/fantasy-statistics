using System;
using Newtonsoft.Json;

namespace fantasy_statistics
{
    public class Player
    {        
        [JsonProperty("assists")]
        public int? Assists { get; set; }

        [JsonProperty("bonus")]
        public int? Bonus { get; set; }

        [JsonProperty("bps")]
        public int? BonusPointsSystem { get; set; }

        [JsonProperty("chance_of_playing_next_round")]
        public int? ChanceOfPlayingNextRound { get; set; }

        [JsonProperty("chance_of_playing_this_round")]
        public int? ChanceOfPlayingThisRound { get; set; }

        [JsonProperty("clean_sheets")]
        public int? CleanSheets { get; set; }

        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("corners_and_indirect_freekicks_order")]
        public int? CornersAndIndirectFreekicksOrder { get; set; }

        [JsonProperty("corners_and_indirect_freekicks_text")]
        public string CornersAndIndirectFreekicksText { get; set; }

        [JsonProperty("cost_change_event")]
        public int? CostChangeEvent { get; set; }

        [JsonProperty("cost_change_event_fall")]
        public int? CostChangeEventFall { get; set; }

        [JsonProperty("cost_change_start")]
        public int? CostChangeStart { get; set; }

        [JsonProperty("cost_change_start_fall")]
        public int? CostChangeStartFall { get; set; }

        [JsonProperty("creativity")]
        public string Creativity { get; set; }

        [JsonProperty("creativity_rank")]
        public int? CreativityRank { get; set; }

        [JsonProperty("creativity_rank_type")]
        public int? CreativityRankType { get; set; }

        [JsonProperty("direct_freekicks_order")]
        public int? DirectFreekicksOrder { get; set; }

        [JsonProperty("direct_freekicks_text")]
        public string DirectFreekicksText { get; set; }

        [JsonProperty("dreamteam_count")]
        public int? DreamteamCount { get; set; }

        [JsonProperty("element_type")]
        public Position Position { get; set; }

        [JsonProperty("ep_next")]
        public string EpNext { get; set; }

        [JsonProperty("ep_this")]
        public string EpThis { get; set; }

        [JsonProperty("event_points")]
        public int? EventPoints { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("goals_conceded")]
        public int? GoalsConceded { get; set; }

        [JsonProperty("goals_scored")]
        public int? GoalsScored { get; set; }

        [JsonProperty("ict_index")]
        public string IctIndex { get; set; }

        [JsonProperty("ict_index_rank")]
        public int? IctIndexRank { get; set; }

        [JsonProperty("ict_index_rank_type")]
        public int? IctIndexRankType { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("in_dreamteam")]
        public bool? InDreamteam { get; set; }

        [JsonProperty("influence")]
        public string Influence { get; set; }

        [JsonProperty("influence_rank")]
        public int? InfluenceRank { get; set; }

        [JsonProperty("influence_rank_type")]
        public int? InfluenceRankType { get; set; }

        [JsonProperty("minutes")]
        public int? MinutesPlayed { get; set; }

        [JsonProperty("news")]
        public string News { get; set; }

        [JsonProperty("news_added")]
        public DateTime? NewsAdded { get; set; }

        [JsonProperty("now_cost")]
        public decimal? NowCost { get; set; }

        [JsonProperty("own_goals")]
        public int? OwnGoals { get; set; }

        [JsonProperty("penalties_missed")]
        public int? PenaltiesMissed { get; set; }

        [JsonProperty("penalties_order")]
        public int? PenaltiesOrder { get; set; }

        [JsonProperty("penalties_saved")]
        public int? PenaltiesSaved { get; set; }

        [JsonProperty("penalties_text")]
        public string PenaltiesText { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("points_per_game")]
        public string PointsPerGame { get; set; }

        [JsonProperty("red_cards")]
        public int? RedCards { get; set; }

        [JsonProperty("saves")]
        public int? Saves { get; set; }

        [JsonProperty("second_name")]
        public string SecondName { get; set; }

        [JsonProperty("selected_by_percent")]
        public string SelectedByPercent { get; set; }

        [JsonProperty("special")]
        public bool? Special { get; set; }

        [JsonProperty("squad_number")]
        public string SquadNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("team_code")]
        public int? TeamCode { get; set; }

        [JsonProperty("threat")]
        public string Threat { get; set; }

        [JsonProperty("threat_rank")]
        public int? ThreatRank { get; set; }

        [JsonProperty("threat_rank_type")]
        public int? ThreatRankType { get; set; }

        [JsonProperty("total_points")]
        public int? TotalPoints { get; set; }

        [JsonProperty("transfers_in")]
        public int? TransfersIn { get; set; }

        [JsonProperty("transfers_in_event")]
        public int? TransfersInEvent { get; set; }

        [JsonProperty("transfers_out")]
        public int? TransfersOut { get; set; }

        [JsonProperty("transfers_out_event")]
        public int? TransfersOutEvent { get; set; }

        [JsonProperty("value_form")]
        public string ValueForm { get; set; }

        [JsonProperty("value_season")]
        public string ValueSeason { get; set; }

        [JsonProperty("web_name")]
        public string WebName { get; set; }

        [JsonProperty("yellow_cards")]
        public int? YellowCards { get; set; }
    }
}