//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\LUFileParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ILUFileParserVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class LUFileParserBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ILUFileParserVisitor<Result>
{
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.file"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitFile([NotNull] LUFileParser.FileContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.paragraph"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitParagraph([NotNull] LUFileParser.ParagraphContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newline"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewline([NotNull] LUFileParser.NewlineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.errorString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitErrorString([NotNull] LUFileParser.ErrorStringContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.nestedIntentSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNestedIntentSection([NotNull] LUFileParser.NestedIntentSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.nestedIntentNameLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNestedIntentNameLine([NotNull] LUFileParser.NestedIntentNameLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.nestedIntentName"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNestedIntentName([NotNull] LUFileParser.NestedIntentNameContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.nameIdentifier"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNameIdentifier([NotNull] LUFileParser.NameIdentifierContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.nestedIntentBodyDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNestedIntentBodyDefinition([NotNull] LUFileParser.NestedIntentBodyDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.subIntentDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitSubIntentDefinition([NotNull] LUFileParser.SubIntentDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.simpleIntentSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitSimpleIntentSection([NotNull] LUFileParser.SimpleIntentSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.intentDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitIntentDefinition([NotNull] LUFileParser.IntentDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.intentNameLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitIntentNameLine([NotNull] LUFileParser.IntentNameLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.intentName"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitIntentName([NotNull] LUFileParser.IntentNameContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.intentBody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitIntentBody([NotNull] LUFileParser.IntentBodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.normalIntentBody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNormalIntentBody([NotNull] LUFileParser.NormalIntentBodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.normalIntentString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNormalIntentString([NotNull] LUFileParser.NormalIntentStringContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntitySection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntitySection([NotNull] LUFileParser.NewEntitySectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityDefinition([NotNull] LUFileParser.NewEntityDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityListbody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityListbody([NotNull] LUFileParser.NewEntityListbodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityLine([NotNull] LUFileParser.NewEntityLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newCompositeDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewCompositeDefinition([NotNull] LUFileParser.NewCompositeDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newRegexDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewRegexDefinition([NotNull] LUFileParser.NewRegexDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityType"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityType([NotNull] LUFileParser.NewEntityTypeContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityRoles"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityRoles([NotNull] LUFileParser.NewEntityRolesContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityUsesFeatures"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityUsesFeatures([NotNull] LUFileParser.NewEntityUsesFeaturesContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityRoleOrFeatures"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityRoleOrFeatures([NotNull] LUFileParser.NewEntityRoleOrFeaturesContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityName"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityName([NotNull] LUFileParser.NewEntityNameContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.newEntityNameWithWS"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNewEntityNameWithWS([NotNull] LUFileParser.NewEntityNameWithWSContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entitySection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntitySection([NotNull] LUFileParser.EntitySectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entityDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntityDefinition([NotNull] LUFileParser.EntityDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entityLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntityLine([NotNull] LUFileParser.EntityLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entityName"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntityName([NotNull] LUFileParser.EntityNameContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entityType"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntityType([NotNull] LUFileParser.EntityTypeContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.compositeEntityIdentifier"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitCompositeEntityIdentifier([NotNull] LUFileParser.CompositeEntityIdentifierContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.regexEntityIdentifier"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitRegexEntityIdentifier([NotNull] LUFileParser.RegexEntityIdentifierContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.entityListBody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitEntityListBody([NotNull] LUFileParser.EntityListBodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.normalItemString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitNormalItemString([NotNull] LUFileParser.NormalItemStringContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.importSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitImportSection([NotNull] LUFileParser.ImportSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.importDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitImportDefinition([NotNull] LUFileParser.ImportDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaSection([NotNull] LUFileParser.QnaSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaDefinition([NotNull] LUFileParser.QnaDefinitionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaSourceInfo"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaSourceInfo([NotNull] LUFileParser.QnaSourceInfoContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaIdMark"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaIdMark([NotNull] LUFileParser.QnaIdMarkContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaQuestion"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaQuestion([NotNull] LUFileParser.QnaQuestionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.questionText"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQuestionText([NotNull] LUFileParser.QuestionTextContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.moreQuestionsBody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitMoreQuestionsBody([NotNull] LUFileParser.MoreQuestionsBodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.moreQuestion"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitMoreQuestion([NotNull] LUFileParser.MoreQuestionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.errorQuestionString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitErrorQuestionString([NotNull] LUFileParser.ErrorQuestionStringContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.qnaAnswerBody"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitQnaAnswerBody([NotNull] LUFileParser.QnaAnswerBodyContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.filterSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitFilterSection([NotNull] LUFileParser.FilterSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.promptSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitPromptSection([NotNull] LUFileParser.PromptSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.filterLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitFilterLine([NotNull] LUFileParser.FilterLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.errorFilterLine"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitErrorFilterLine([NotNull] LUFileParser.ErrorFilterLineContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.multiLineAnswer"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitMultiLineAnswer([NotNull] LUFileParser.MultiLineAnswerContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.modelInfoSection"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitModelInfoSection([NotNull] LUFileParser.ModelInfoSectionContext context) { return VisitChildren(context); }
    /// <summary>
    /// Visit a parse tree produced by <see cref="LUFileParser.modelInfoDefinition"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    public virtual Result VisitModelInfoDefinition([NotNull] LUFileParser.ModelInfoDefinitionContext context) { return VisitChildren(context); }
}
